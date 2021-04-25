import { AfterViewInit, Component, Input, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatSort } from '@angular/material/sort';
import { DriverService } from '../services/driver.service';
import { MatTableDataSource } from '@angular/material';


@Component({
  selector: 'driver-reports',
  templateUrl: './driver-reports.component.html',
  styleUrls: ['./driver-reports.component.css']
})
export class DriverReportsComponent implements AfterViewInit {

  @Input()
  @ViewChild(MatSort, {static: false}) sort: MatSort;
  requiredFileType: string;

  driverService:DriverService;
  reportResponse = new MatTableDataSource();
  columnsToDisplay: string[] = ['driver', 'miles', 'milesMph'];

  constructor(private http: HttpClient) {
    this.driverService = new DriverService(http);
    this.displayData();
  }

  ngAfterViewInit(): void {
    this.reportResponse.sort = this.sort;
  }

  private displayData() {
    this.driverService.GetDriverReportData()
      .subscribe(data => {
        this.reportResponse.data = data;
      });        
  }

  public refresh() {
    this.displayData();
  }

}
