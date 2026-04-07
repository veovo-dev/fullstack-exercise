import { Component, inject, OnInit, signal } from '@angular/core';
import { IFlight } from './models/flight.interface';
import { DataGridComponent } from './components/data-grid/data-grid.component';
import { FlightService } from './services/flight.service';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [DataGridComponent],
    templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
    private readonly flightService = inject(FlightService);
    data = signal<IFlight[]>([]);

    ngOnInit(): void {
        this.flightService.getFlights().subscribe(flights => this.data.set(flights));
    }
}
