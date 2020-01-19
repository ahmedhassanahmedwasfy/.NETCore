import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PickListModule} from 'primeng/picklist';
import { CarService } from './CarService'
import {TableModule} from 'primeng/table';
import {DropdownModule} from 'primeng/dropdown';

@NgModule({
  imports: [
    TableModule, CommonModule,PickListModule,DropdownModule
  ],
  exports: [TableModule,PickListModule,DropdownModule],
  declarations: [ ],
  providers:[CarService]
})
export class PrimeNGLoaderModule { }
