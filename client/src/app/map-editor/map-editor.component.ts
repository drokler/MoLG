import { Component, ViewChild } from '@angular/core';
import { MapComponent } from '@maplibre/ngx-maplibre-gl';
import { StyleSpecification } from 'maplibre-gl';

interface Editor {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-map-editor',
  templateUrl: './map-editor.component.html',
  styleUrls: ['./map-editor.component.css']
})
export class MapEditorComponent {

  @ViewChild("map") map: MapComponent;

  selectedEditor: string;
  editors: Editor[] = [
    {value: 'locations', viewValue: 'Точки интереса'},
    {value: 'routes', viewValue: 'Маршруты npc'},
  ];


  public zoom: [number] = [2];
  public style: StyleSpecification = {
    version: 8,
    sources: {
      rastertiles: {
        type: 'raster',
        tiles: [
          // NOTE: Layers from Stadia Maps do not require an API key for localhost development or most production
          // web deployments. See https://docs.stadiamaps.com/authentication/ for details.
          'https://tiles.stadiamaps.com/tiles/stamen_watercolor/{z}/{x}/{y}.jpg',
        ],
        tileSize: 256,
        attribution:
          'Map tiles by <a target="_blank" href="http://stamen.com">Stamen Design</a>; Hosting by <a href="https://stadiamaps.com/" target="_blank">Stadia Maps</a>. Data &copy; <a href="https://www.openstreetmap.org/about" target="_blank">OpenStreetMap</a> contributors',
      },
    },
    layers: [
      {
        id: 'simple-tiles',
        type: 'raster',
        source: 'rastertiles',
        minzoom: 0,
        maxzoom: 22,
      },
    ],
  };

  public onZoomEnd(event: any){
    console.log(event);
    console.log(this.map?.zoom);
  }
}
