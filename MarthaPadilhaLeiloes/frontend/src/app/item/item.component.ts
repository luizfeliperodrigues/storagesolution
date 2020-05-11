import { Component, OnInit, TemplateRef } from '@angular/core';
import { ItemService } from '../_services/item.service';
import { Item } from '../_models/Item';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { TipoItem } from '../_models/TipoItem';
import { TipoItemService } from '../_services/tipoItem.service';
import { ComitenteService } from '../_services/comitente.service';
import { Comitente } from '../_models/Comitente';


@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  title = 'Itens';
  itemsFiltrados: Item[];
  items: Item[];
  item: Item;
  registerForm: FormGroup;
  bodyDeleteItem = '';
  tipoItems: TipoItem[];
  comitentes: Comitente[];

  infoSave = 'post';

  filtrolista: string;
  get filtroLista(): string{
    return this.filtrolista;
  }
  set filtroLista(value: string){
    this.filtrolista = value;
    this.itemsFiltrados = this.filtroLista !== '' ? this.filtrarItems(this.filtroLista) : this.items;
  }

  constructor(
      private itemService: ItemService
    , private tipoItemService: TipoItemService
    , private comitenteService: ComitenteService
    , private toastr: ToastrService
    , private fb: FormBuilder
  ) { }

  ngOnInit() {
    this.getItems();
    this.getTipoItems();
    this.getComitentes()
    this.validation();
  }

  filtrarItems(filtrarPor: string): Item[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.items.filter(
      i => i.businessCode.toLocaleString().indexOf(filtrarPor) !== -1
    );
  }

  openModal(template: any){
    this.registerForm.reset();
    template.show();
  }

  getItems(){
    this.itemService.getAllItems().subscribe(
      (_items: Item[]) => {
      this.items = _items;
      console.log(_items);
      }, error => {
        this.toastr.error(`Erro ao tentar carregar os item: ${error}`);
    });
  }

  validation(){
    this.registerForm = this.fb.group({
      businessCode: ['',
      [Validators.required, Validators.pattern('[1-9]*')]],
      description: ['',
      [Validators.required, Validators.minLength(3)]],
      priceReference: ['',
      [Validators.required, Validators.pattern('[1-9]*')]],
      storedQuantity: ['',
      [Validators.required, Validators.pattern('[1-9]*')]],
      local: ['',
      [Validators.required, Validators.minLength(3)]]
    });
  }

  newItem(template: any){
    this.infoSave = 'post';
    this.openModal(template);
  }

  editItem(item: Item, template: any){
    this.infoSave = 'put';
    this.openModal(template);
    this.item = item;
    this.registerForm.patchValue(item);
  }

  excludeItem(item: Item, template: any) {
    this.openModal(template);
    this.item = item;
    this.bodyDeleteItem = `Tem certeza que deseja excluir o item: ${item.businessCode}?`;
  }

  confirmDelete(template: any) {
    this.itemService.deleteItem(this.item.id).subscribe(
      () => {
          template.hide();
          this.getItems();
          this.toastr.success('Deletado com sucesso!');
        }, error => {
          this.toastr.error('Erro ao tentar deletar.');
          console.log(error);
        }
    );
  }

  saveItem(template: any){
    if(this.registerForm.valid){
      if (this.infoSave === 'post') {
        this.item = Object.assign({}, this.registerForm.value);
        this.itemService.postItem(this.item).subscribe(
          () => {
            template.hide();
            this.getItems();
            this.toastr.success('Item criado com sucesso!');
          }, error => {
            console.log(error);
            console.log(this.item);
            this.toastr.error(`Erro ao criar o leilão: ${error}`);
          }
        );
      }

      if (this.infoSave === 'put') {
        this.item = Object.assign({id: this.item.id}, this.registerForm.value);
        this.itemService.putItem(this.item).subscribe(
          () => {
            template.hide();
            this.getItems();
            this.toastr.success('Item editado com sucesso!');
          }, error => {
            this.toastr.error(`Erro ao editar o leilão: ${error}`);
          }
        );
      }
    }
  }

  getTipoItems(){
    this.tipoItemService.getAllTipos().subscribe(
      (_tipoItems: TipoItem[]) => {
      this.tipoItems = _tipoItems;
      }, error => {
        this.toastr.error(`Erro ao tentar carregar os tipos: ${error}`);
    });
  }

  getComitentes(){
    this.comitenteService.getAllComitente().subscribe(
      (_comitentes: Comitente[]) => {
      this.comitentes = _comitentes;
      }, error => {
        this.toastr.error(`Erro ao tentar carregar os tipos: ${error}`);
    });
  }

}
