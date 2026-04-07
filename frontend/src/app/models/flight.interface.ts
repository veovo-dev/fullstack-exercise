export interface IFlight {
    id: number;
    flightNumber: string;
    airline: string | null;
    origin: string | null;
    destination: string | null;
    vector: string | null;
    aircraftType: string | null;
    stand: string | null;
    gate: string | null;
    terminal: string | null;
    status: string | null;
    dtScheduled: string;
    dtEstimated: string | null;
    dtActual: string | null;
    linkedFlight: string | null;
    dtCreatedAt: string;
}
