import { Component } from '@angular/core';
import { NgForm } from "@angular/forms";
import { error } from 'console';
import { NewTransaction } from 'src/app/shared/models/transaction-new.model';
import { Transaction } from 'src/app/shared/models/transaction.model';
import { TransactionService } from 'src/app/shared/services/transaction.service';

@Component({
  selector: 'app-transaction-new',
  templateUrl: './transaction-new.component.html',
  styleUrls: ['./transaction-new.component.css']
})
export class TransactionNewComponent {

  constructor(public transactionService: TransactionService){

  }

  onSubmit(form: NgForm){
    if(form.valid){
      this.transactionService.createTransaction()
        .subscribe({
          next: response => {
            this.transactionService.transactionsList = response as Transaction[]
            this.resetForm(form)
          },
          error: err => {
            console.log(err)
          }
        });
    }
  }

  resetForm(form: NgForm){
    form.form.reset()
    this.transactionService.formData = new NewTransaction()
  }
}
