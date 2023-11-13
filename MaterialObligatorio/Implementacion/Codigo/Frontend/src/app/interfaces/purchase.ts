export class PurchaseRequest {
    buyerEmail: string = "";
    purchaseDate: string = "";
    details: PurchaseRequestDetail[] = [];
    detailsProduct : PurchaseRequestDetailProduct[] = [];

    constructor(buyerEmail: string, 
                    purchaseDate: string, 
                    details: PurchaseRequestDetail[],
                    detailsProduct: PurchaseRequestDetailProduct[],
                    ){
        this.buyerEmail = buyerEmail;
        this.purchaseDate = purchaseDate;
        this.details = details;
        this.detailsProduct = detailsProduct;
    }
}

export class PurchaseRequestDetailProduct {
  id: number = 0;
  quantity: number = 1;
  pharmacyId: number = 1;

  constructor(id: number, 
                        quantity: number, 
                        pharmacyId: number){
      this.id = id;
      this.quantity = quantity;
      this.pharmacyId = pharmacyId;
  }
}
export class PurchaseRequestDetail {
  code: string = "";
  quantity: number = 1;
  pharmacyId: number = 1;

  constructor(code: string, 
                        quantity: number, 
                        pharmacyId: number){
      this.code = code;
      this.quantity = quantity;
      this.pharmacyId = pharmacyId;
  }
}

export interface PurchaseResponse {
  id: number;
  buyerEmail: string;
  purchaseDate: string;
  trackingCode: string;
  totalAmount: number;
  details: PurchaseDetailModelResponse[]
  detailsProduct: PurchaseDetailProductModelResponse[]
}

export interface PurchaseDetailModelResponse {
  id: number;
  code: string;
  name: string;
  quantity: number;
  price: number;
  pharmacyId: number;
  pharmacyName: string;
  status: string;
}
export interface PurchaseDetailProductModelResponse {
  id: number;
  name: string;
  quantity: number;
  price: number;
  pharmacyId: number;
  pharmacyName: string;
  status: string;
}

export interface PurchaseModelResponseStatus {
  purchaseId: number;
  purchaseDetailId: number;
  drugCode: string;
  drugName: string;
  quantity: number;
  price: number;
  pharmacyId: number;
  pharmacyName: string;
  status: string;
}