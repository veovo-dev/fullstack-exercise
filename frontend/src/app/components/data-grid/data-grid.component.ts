import { Component, input } from '@angular/core';
import { IFlight } from 'src/app/models/flight.interface';
import { GridHeaderComponent } from './header/header.component';
import { RowComponent } from './row/row.component';

@Component({
    selector: 'data-grid',
    standalone: true,
    imports: [GridHeaderComponent, RowComponent],
    templateUrl: './data-grid.component.html',
    styleUrls: ['./data-grid.component.scss'],
})
export class DataGridComponent {
    public readonly sampleHeaders = [
        'flight',
        'sch. date',
        'sch. time',
        'o/d',
        'aircraft',
        'linked',
    ];

    rows = input<IFlight[]>([]);
}
