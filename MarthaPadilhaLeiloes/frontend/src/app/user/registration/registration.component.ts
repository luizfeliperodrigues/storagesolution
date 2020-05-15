import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/User';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  registerForm: FormGroup;
  user: User;

  constructor(
        private fb: FormBuilder
      , private router: Router
      , private toastr: ToastrService
      , private authService: AuthService
  ) { }

  ngOnInit() {
    this.validation();
  }

  validation(){
    this.registerForm = this.fb.group({
      fullName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      userName: ['', Validators.required],
      passwords: this.fb.group({
        password: ['', [Validators.required, Validators.minLength(4)]],
        confirmPassword: ['', Validators.required]
      }, { validator: this.comparePasswords })
    });
  }

  comparePasswords(fb: FormGroup){
    const confirmPasswordControl = fb.get('confirmPassword');
    if (confirmPasswordControl.errors == null || 'mismatch' in confirmPasswordControl.errors) {
      if (fb.get('password').value !== confirmPasswordControl.value) {
        confirmPasswordControl.setErrors({ mismatch: true });
      } else {
        confirmPasswordControl.setErrors(null);
      }
    }
  }

  registerUser(){
    if (this.registerForm.valid) {
      this.user = Object.assign({ 
        password: this.registerForm.get('passwords.password').value }, this.registerForm.value
      );

      this.authService.register(this.user).subscribe(
        () => {
          this.router.navigate(['/user/login']);
          this.toastr.success('Cadastrado com sucesso!');
        }, error => {
          const err = error.error;
          err.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Esse usuario já foi cadastrado.');
                break;
              default:
                this.toastr.error(`Erro no cadastro! CODE: ${element.code}`);
                break;
            }
          });
        }
      );
    }
  }

}
