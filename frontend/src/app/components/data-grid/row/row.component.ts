import { Component, input } from '@angular/core';
import { DatePipe } from '@angular/common';
import { IFlight } from 'src/app/models/flight.interface';

@Component({
    selector: 'data-row',
    standalone: true,
    imports: [DatePipe],
    templateUrl: './row.component.html',
    styleUrls: ['./row.component.scss'],
})
export class RowComponent {
    row = input.required<IFlight>();
}
