import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IFlight } from '../models/flight.interface';

@Injectable({ providedIn: 'root' })
export class FlightService {
    private readonly http = inject(HttpClient);

    getFlights(): Observable<IFlight[]> {
        return this.http.get<IFlight[]>('/api/flight');
    }
}
