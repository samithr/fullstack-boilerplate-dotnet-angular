import { Injectable } from '@angular/core';
import { NewTransaction } from '../models/transaction-new.model';
import { Transaction } from '../models/transaction.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  formData: NewTransaction = new NewTransaction();
  transactionsList: Transaction[] = [];
  apiUrl: string = environment.baseApiUrl + 'transaction';

  constructor(private httpClient: HttpClient) { }

  createTransaction(){
    return this.httpClient.post(this.apiUrl, this.formData)
  }

}
