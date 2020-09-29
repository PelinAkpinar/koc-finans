
import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class CreditService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'http://localhost:31004/';

  formModel = this.fb.group({
    TCKN: ['', Validators.required],
    Name: ['', Validators.required],
    Surname: ['', Validators.required],
    Salary: ['', Validators.required],
    Phone: ['', Validators.required],

  });


  register() {
    var body = {
      TCKN: this.formModel.value.TCKN,
      Name: this.formModel.value.Name,
      Surname: this.formModel.value.Surname,
      Salary: this.formModel.value.Salary,
      Phone: this.formModel.value.Phone,

    };

      return Observable.create(observer => {
        var data = new FormData();
        data.append("IdentityNo", this.formModel.value.TCKN);
        data.append("Name", this.formModel.value.Name);
        data.append("SurName", this.formModel.value.Surname);
        data.append("PhoneNumber", this.formModel.value.Phone);
        data.append("Salary", this.formModel.value.Salary);
        var xhr = new XMLHttpRequest();
        xhr.withCredentials = true;

      xhr.open("POST", "http://localhost:31004/api/useCredit");
      xhr.withCredentials = true;
      xhr.send(data);
        xhr.onreadystatechange = () => {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    console.log(xhr.response);
                    observer.next(JSON.parse(xhr.response));
                    observer.complete();
                } else {
                  console.log(xhr.response);
                observer.error(xhr.response);
                }
            }
        };

    });
  }
}
