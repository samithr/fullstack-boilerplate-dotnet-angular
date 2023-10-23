import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TransactionNewComponent } from './components/transaction-new/transaction-new.component';
import { TransactionListComponent } from './components/transaction-list/transaction-list.component';

@NgModule({
  declarations: [
    AppComponent,
    TransactionNewComponent,
    TransactionListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
