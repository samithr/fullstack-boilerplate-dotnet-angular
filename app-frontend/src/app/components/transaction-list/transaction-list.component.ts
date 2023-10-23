import { Component, OnInit } from '@angular/core';
import { Transaction } from 'src/app/shared/models/transaction.model';
import { TransactionService } from 'src/app/shared/services/transaction.service';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.css']
})
export class TransactionListComponent implements OnInit {

  withdrawalTransactionsList: Transaction[] = [];
  depositTransactionsList: Transaction[] = [];

  constructor(public transacionService: TransactionService){}

  ngOnInit(): void {
    this.withdrawalTransactionsList = this.transacionService.transactionsList
      .filter(transaction => transaction.transactionType == TransactionType.Withdraw)
      
      this.depositTransactionsList = this.transacionService.transactionsList
      .filter(transaction => transaction.transactionType == TransactionType.Deposit)
  

    }
}
