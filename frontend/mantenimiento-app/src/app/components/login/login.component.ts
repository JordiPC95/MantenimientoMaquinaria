import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private ApiService: ApiService) {}

  login() {
    this.ApiService.login(this.email, this.password).subscribe(
      (response: any) => {
        localStorage.setItem('token', response.token); // Guardar el token en el navegador
        alert('Login exitoso!');
      },
      error => {
        alert('Credenciales incorrectas');
      }
    );
  }
}
