import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { environment } from '../../environments/environment';
import { Category } from './category.model';
import { NgForm } from '@angular/forms';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private https: HttpClient) { }

  url: string = environment.apiBaseUrl + '/Category'
  list:Category[] = []
  formData: Category = new Category()
  formSubmitted: boolean = false;

  refreshList(){
    this.https.get(this.url)
      .subscribe({
        next: res => {
          this.list = res as Category[]
        },
        error: err => {console.log(err)}
      })
  }

  
  postCategoryDetail()
  {
    return this.https.post(this.url, this.formData)
  }

  putCategoryDetail()
  {
    return this.https.put(this.url + '/' + this.formData.id , this.formData)
  }

  deleteCategoryDetail(id:number)
  {
    return this.https.delete(this.url + '/' + id )
  }

  resetForm(form:NgForm){
    form.form.reset()
    this.formData = new Category()
    this.formSubmitted = false

  }

}
