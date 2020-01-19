import { Component, OnInit, ViewEncapsulation } from '@angular/core';
 
import { SelectItem } from 'primeng/components/common/selectitem';
import { TranslateService } from '@ngx-translate/core';
import { Car } from '../../../../@theme/PrimeNGLoader/domain/Car';
import { CarService } from '../../../../@theme/PrimeNGLoader/CarService';

@Component({
    selector: 'ngx-DataView',
    templateUrl: './DataView.component.html',
    styleUrls: ['./DataView.component.scss'],
        // encapsulation:ViewEncapsulation.None
})
export class DataViewComponent implements OnInit {
    cars: Car[];

    selectedCar: Car;

    displayDialog: boolean;

    sortOptions: SelectItem[];

    sortKey: string;

    sortField: string;

    sortOrder: number;
    // people:person[];
    // ApplicationName;
    async ngOnInit() {
         
    }
    constructor(private CarService: CarService, private translate: TranslateService) {
        this.sortOptions = [
            { label: 'Newest First', value: '!year' },
            { label: 'Oldest First', value: 'year' },
            { label: 'Brand', value: 'brand' }
        ];
        this.CarService.getCarsLarge()
            .then(res => { return res.json() })
            .then(data => { this.cars = data; });

    }
    selectCar(event: Event, car: Car) {
        this.selectedCar = car;
        this.displayDialog = true;
        event.preventDefault();
    }

    onSortChange(event) {
        let value = event.value;

        if (value.indexOf('!') === 0) {
            this.sortOrder = -1;
            this.sortField = value.substring(1, value.length);
        }
        else {
            this.sortOrder = 1;
            this.sortField = value;
        }
    }

    onDialogHide() {
        this.selectedCar = null;
    }


}
