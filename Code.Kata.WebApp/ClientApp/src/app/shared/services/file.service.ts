import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../../config/constants';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor(private http: HttpClient, private constants: Constants) { }

  public UploadFile(formData) {
    return this.http.post(this.constants.API_ENDPOINT + "/File/FileUpload", formData, {
      reportProgress: true,
      observe: 'events'
    })
  }
}
