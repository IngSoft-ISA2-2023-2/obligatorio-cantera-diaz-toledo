import { Component, OnInit } from '@angular/core';
import { cilCart, cilPlus, cilCompass, cilCheckCircle, cilTrash } from '@coreui/icons';
import { IconSetService } from '@coreui/icons-angular';
import { Drug } from 'src/app/interfaces/drug';
import { StorageManager } from '../../../utils/storage-manager';
import { Router } from '@angular/router';
import { CommonService } from '../../../services/CommonService';
import { Product } from 'src/app/interfaces/product';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {  
  cart: Drug[]  = [];
  cartProduct: Product[]  = [];
  total: number = 0;

  constructor(
    public iconSet: IconSetService,
    private storageManager: StorageManager,
    private router: Router,
    private commonService: CommonService) {
    iconSet.icons = { cilCart, cilPlus, cilCompass, cilCheckCircle, cilTrash };
  }

  ngOnInit(): void {
    this.cart = JSON.parse(this.storageManager.getData('cart'));
    this.cartProduct = JSON.parse(this.storageManager.getData('cartProduct'));
    if (!this.cart) {
      this.cart = [];
      this.storageManager.saveData('cart', JSON.stringify(this.cart));
    }
    if (!this.cartProduct) {
      this.cartProduct = [];
      this.storageManager.saveData('cartProduct', JSON.stringify(this.cartProduct));
    }
    this.storageManager.saveData('total', JSON.stringify(0));
    this.updateTotal();
  }

  delete(index: number){
    this.cart = JSON.parse(this.storageManager.getData('cart'));
    this.cartProduct = JSON.parse(this.storageManager.getData('cartProduct'));
    this.cart.splice(index, 1);
    this.cartProduct.splice(index, 1);
    this.storageManager.saveData('cart', JSON.stringify(this.cart));
    this.storageManager.saveData('cartProduct', JSON.stringify(this.cartProduct));
    this.updateTotal();
    this.updateHeader(this.cart.length);
    this.updateHeader(this.cartProduct.length);
  }

  updateTotal(){
    this.total = 0;
    this.cart = JSON.parse(this.storageManager.getData('cart'));
    this.cartProduct = JSON.parse(this.storageManager.getData('cartProduct'));
    for(let item of this.cart){
      this.total += (item.price * item.quantity);
    }
    for(let item of this.cartProduct){
      
      this.total += (item.precio);
    }

  }

  updateHeader(value: number){
    this.commonService.updateHeaderData(value);
   }

  goToCho(){
    this.storageManager.saveData('total', JSON.stringify(this.total));
    this.router.navigate(['/home/cart/cho']);
  }
  
}
