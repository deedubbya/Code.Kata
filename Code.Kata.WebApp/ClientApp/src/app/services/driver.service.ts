import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DriverReportData } from '../models/driver-report-data';

@Injectable({
  providedIn: 'root'
})
export class DriverService {

  constructor(private http: HttpClient) { }

  public GetDriverReportData() {
    return this.http.get<DriverReportData[]>("https://localhost:44391/api/Driver/GetDriverReportData")
  }
}
