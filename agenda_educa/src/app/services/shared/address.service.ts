import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

constructor(private _http: HttpClient) { }

//Valida o formato do cep
private validateCep(cep: string) {
  const validateCep = /^[0-9]{8}$/;
  return validateCep.test(cep);
}

//Faz buca do cep no via cep
getAddress(inputValue: any) {
  let cep = inputValue.target.value.replace(/\D/g, '');

  if(this.validateCep(cep)) {
    return this._http.get("https://viacep.com.br/ws/" + cep + "/json");
  }

  return null;
}

showAddress(data: any, form: FormGroup) {
  form.patchValue({
    cep: data?.cep,
    city: data?.localidade,
    street: data?.logradouro,
    district: data?.bairro,
    state: this.getStateByUf(data?.uf?.toUpperCase())
  });
}

private getStateByUf(state: string) {
  switch(state) {
    case "MG":
      return "Minas Gerais";
    case "SP":
      return "São Paulo";
    case "RR":
      return "Roraima";
    case "AP":
      return "Amapá";
    case "AM":
      return "Amazonas";
    case "PA":
      return "Pará";
    case "AC":
      return "Acre";
    case "RO":
      return "Rondônia";
    case "TO":
      return "Tocantins";
    case "MA":
      return "Maranhão";
    case "PI":
      return "Piauí";
    case "CE":
      return "Ceará";
    case "RN":
      return "Rio Grande do Norte";
    case "PB":
      return "Paraíba";
    case "PE":
      return "Pernambuco";
    case "AL":
      return "Alagoas";
    case "SE":
      return "Sergipe";
    case "BA":
      return "Bahia";
    case "MT":
      return "Mato Grosso";
    case "DF":
      return "Distrito Federal";
    case "GO":
      return "Goiás";
    case "MS":
      return "Mato Grosso do Sul";
    case "ES":
      return "Espírito Santo";
    case "RJ":
      return "Rio de Janeiro";
    case "PR":
      return "Paraná";
    case "SC":
      return "Santa Catarina";
    case "RS":
      return "Rio Grande do Sul"
  }

  return null;
}

}
