import { Component, OnInit } from '@angular/core';
import { cilThumbUp, cilCart, cilPlus, cilCompass } from '@coreui/icons';
import { IconSetService } from '@coreui/icons-angular';
import { Router } from '@angular/router';
import { PurchaseService } from '../../../services/purchase.service';
import { StorageManager } from '../../../utils/storage-manager';
import { PurchaseRequest, PurchaseRequestDetail, PurchaseRequestDetailProduct } from 'src/app/interfaces/purchase';
import { CommonService } from '../../../services/CommonService';
import { Drug } from 'src/app/interfaces/drug';
import { Product } from 'src/app/interfaces/product';

@Component({
  selector: 'app-cho',
  templateUrl: './cho.component.html',
  styleUrls: ['./cho.component.css']
})
export class ChoComponent implements OnInit {
  total: number = 0;
  email: string = "";
  cart: Drug[] = [];
  cartProduct: Product[] = [];


  constructor(
    public iconSet: IconSetService,
    private router: Router,
    private purchaseService: PurchaseService,
    private storageManager: StorageManager,
    private commonService: CommonService) {
    iconSet.icons = { cilThumbUp, cilCart, cilPlus, cilCompass };
  }

  ngOnInit(): void {
    this.updateCart();
    let _total = JSON.parse(this.storageManager.getData('total'));
    this.total = 0;
    if (_total){
      this.total = _total;
    }
  }

  finishPurchase(): void {
    let cart = JSON.parse(this.storageManager.getData('cart'));
    let cartProduct = JSON.parse(this.storageManager.getData('cartProduct'));
    let details : PurchaseRequestDetail[] = [];
    let detailsProduct : PurchaseRequestDetailProduct[] = [];
    for (const item of cart) {
      let detail = new PurchaseRequestDetail(item.code, item.quantity, item.pharmacy.id);
      details.push(detail);
    }
    for (const item of cartProduct) {
      let detail = new PurchaseRequestDetailProduct(item.id,1, item.pharmacy.id);
      detailsProduct.push(detail);
    }

    let now = new Date().toISOString();
    let purchaseRequest = new PurchaseRequest(this.email, now, details, detailsProduct);
    console.log(purchaseRequest);
    this.purchaseService.addPurchase(purchaseRequest)
    .subscribe(purchase => {
      if (purchase){
        console.log(purchase);
        this.commonService.updateToastData(
                  "Tracking code: " + purchase.trackingCode, 
                  "success", 
                  "Thank you for your purchase.");
        this.storageManager.removeData("cart");    
        this.storageManager.removeData("cartProduct");      
        this.router.navigate(['/home']);
      }
    });
  }

  updateCart(): void {
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
  }
}
