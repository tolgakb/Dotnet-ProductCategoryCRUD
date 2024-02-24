import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { environment } from '../../environments/environment';
import { Product } from './product.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private https: HttpClient) { }


  url: string = environment.apiBaseUrl + '/Product'
  list:Product[] = []
  formData: Product = new Product()
  formSubmitted: boolean = false;

  refreshList(){
    this.https.get(this.url)
      .subscribe({
        next: res => {
          this.list = res as Product[]
        },
        error: err => {console.log(err)}
      })
  }

  postProductDetail()
  {
    return this.https.post(this.url, this.formData)
  }

  putProductDetail()
  {
    return this.https.put(this.url + '/' + this.formData.id , this.formData)
  }

  deleteProductDetail(id:number)
  {
    return this.https.delete(this.url + '/' + id )
  }

  resetForm(form:NgForm){
    form.form.reset()
    this.formData = new Product()
    this.formSubmitted = false

  }
}
