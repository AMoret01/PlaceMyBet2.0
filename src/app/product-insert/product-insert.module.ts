import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ProductInsertPageRoutingModule } from './product-insert-routing.module';

import { ProductInsertPage } from './product-insert.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ProductInsertPageRoutingModule
  ],
  declarations: [ProductInsertPage]
})
export class ProductInsertPageModule {}
