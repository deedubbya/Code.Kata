import { Component, Input } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { finalize, map } from 'rxjs/operators';
import { FileService } from '../shared/services/file.service';
import { FileUploadResponse } from '../shared/models/file-upload-response';

@Component({
  selector: 'update-driver-database',
  templateUrl: './update-driver-database.component.html',
  styleUrls: ['./update-driver-database.component.css']
})
export class UpdateDriverDatabaseComponent {

  @Input()
  requiredFileType: string;

  fileName = '';
  isUploading: boolean;
  isUploaded: boolean;
  uploadProgress: number;
  uploadResponse: FileUploadResponse | undefined;
  uploadSub: Subscription;

  constructor(private fileService: FileService) {
    this.uploadResponse = new FileUploadResponse();
  }

  onFileSelected(event) {
    const file: File = <File>event.target.files[0];
    if (file) {
      const formData = new FormData();
      formData.append('FormName', 'driverupload');
      formData.append('FormFile', file);

      const upload$ = this.fileService.UploadFile(formData)
        .pipe(
          finalize(() => {
            this.isUploading = false;
            this.isUploaded = true;
            this.uploadProgress = null;
            this.uploadSub = null;
          })
        )

      this.uploadSub = upload$.subscribe(
        event => {
          this.isUploading = true;
          if (event.type == HttpEventType.UploadProgress) {
            this.uploadProgress = Math.round(100 * (event.loaded / event.total));
          }
          if (event["body"]) {
            this.uploadResponse = <FileUploadResponse>event["body"];
            console.log("RETURN");
            console.log(this.uploadResponse);
          }
        })
    }
  }

  cancelUpload() {
    this.uploadSub.unsubscribe();
    this.reset();
  }

  reset() {
    this.isUploaded = false;
  }

}
