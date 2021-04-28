import { AbstractControl, FormGroup } from "@angular/forms";

export class ValidatorField {

  static MustMach(controlName: string, MatchingControlName: string): any{
    return (group: AbstractControl) => {
      const formGroup = group as FormGroup;
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[MatchingControlName];

      // if (matchingControl.errors && !matchingControl.errors.mustMatch){
      //   return null;
      // }
      if(control.value !== matchingControl.value){
        matchingControl.setErrors({mustMatch: true});
      }
      else{
        matchingControl.setErrors(null);
      }
       // return null;
    };
  }
}
