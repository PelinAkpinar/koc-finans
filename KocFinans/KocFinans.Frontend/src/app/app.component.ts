import { CreditService } from './shared/credit.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(public service: CreditService,private toastr: ToastrService ) {
    toastr.toastrConfig.progressBar = true;
    toastr.toastrConfig.easeTime = 900;
   }

  ngOnInit() {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register()
    .subscribe(
      (res: any) => {
        console.log(res);
        if (res.success) {
          this.toastr.success("Krediniz Onaylanmistir !"+"Basvuru no :" +res.applicationId+
          "Miktar :" +res.amount,'Success');
          this.service.formModel.reset();
        }
        else {

          this.toastr.error("Krediniz onaylanmamistir",'Error');
        }
      },
      err => {
        console.log(err);
      }
    );
  }

}
