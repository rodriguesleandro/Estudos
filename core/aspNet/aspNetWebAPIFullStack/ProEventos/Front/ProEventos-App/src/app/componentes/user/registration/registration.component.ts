import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from 'src/app/helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {


  form!: FormGroup;
  constructor(public fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  get f(): any { return this.form.controls; }

  public validation(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMach("senha", "confirmeSenha")
    };

    this.form = this.fb.group(
      {
        primeiroNome: ['', Validators.required] ,
        ultimoNome: ['', Validators.required] ,
        email: ['', [Validators.required, Validators.email]] ,
        usuario: ['', Validators.required] ,
        senha: ['', Validators.required] ,
        confirmeSenha: ['', Validators.required] ,
        // concordarTermos

      }, formOptions
    );
  }

}
