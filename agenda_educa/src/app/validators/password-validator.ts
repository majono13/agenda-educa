import { FormGroup } from '@angular/forms';

export class ValidatorPassword {
  static Equal(control: FormGroup) {
    if (!control.parent) return null;

    const password = control.parent.get('password')?.value ?? '';
    const rePassword = control.parent.get('rePassword')?.value ?? '';

    if (password === rePassword) return null;

    return { matchingPassword: true };
  }
}
