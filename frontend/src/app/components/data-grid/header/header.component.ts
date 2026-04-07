import { Component, input } from '@angular/core';

@Component({
    selector: 'grid-header',
    standalone: true,
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss'],
})
export class GridHeaderComponent {
    headers = input.required<string[]>();
}
