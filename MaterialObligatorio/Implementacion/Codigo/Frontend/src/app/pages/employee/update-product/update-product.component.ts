import { Component, OnInit } from "@angular/core";
import { AbstractControl, FormBuilder, FormControl, FormGroup } from "@angular/forms";
import { Pharmacy } from "src/app/interfaces/pharmacy";
import { Role } from "src/app/interfaces/role";
import { CommonService } from "src/app/services/CommonService";
import { InvitationRequest } from 'src/app/interfaces/invitation';
import { InvitationService } from "src/app/services/invitation.service";
import { PharmacyService } from "src/app/services/pharmacy.service";
import { RoleService } from "src/app/services/role.service";
import { cilShortText, cilPencil, cilSync } from '@coreui/icons';
import { ActivatedRoute, Router } from "@angular/router";
import { Invitation } from "src/app/interfaces/invitation";
import { Product } from "src/app/interfaces/product";
import { ProductService } from "src/app/services/product.service";
import { ProductRequest } from "src/app/interfaces/product";

@Component({
    selector: 'app-update-product',
    templateUrl: './update-product.component.html',
    styleUrls: ['./update-product.component.css'],
})

export class UpdateProductComponent implements OnInit {
    form: FormGroup | any;
    pharmacies: Pharmacy[] = [];
    roles: Role[] = [];
    product: Product | any;
    nombreFarmacia = '';

    icons = { cilShortText, cilPencil, cilSync }

    constructor(
        private fb: FormBuilder,
        private pharmacyService: PharmacyService,
        private roleService: RoleService,
        private productService: ProductService,
        private commonService: CommonService,
        private router: Router,
        private route: ActivatedRoute) {
            this.form = fb.group({
                userName: new FormControl(),
                userPrecio: 0 ,
                userDescripcion: new FormControl()
            });
            this.product = null;
        };

    ngOnInit(): void {
        let id = this.route.snapshot.paramMap.get('id');
        this.getInvitationById(id);
    }

    getInvitationById(id: any): void {
        this.productService
        .getProductById(id)
        .subscribe((product) => {
            this.product = product;

            
            this.setDetaultPharmacy(this.product.pharmacy.name);
            console.log(this.product.pharmacy.name);

            this.setDefaultUserName(this.product.nombre);

            this.setDefaultPrecio(this.product.precio);

            this.setDefaultDescripcion(this.product.descripcion);
        })
        
    }

    setDetaultPharmacy(pharmacyName: string): void {
        this.nombreFarmacia = pharmacyName;
    }

    setDefaultUserName(userName: string): void {
        this.form.controls.userName.setValue(userName);
    }
    
    setDefaultPrecio(userPrecio: number): void {
        this.form.controls.userPrecio.setValue(userPrecio);
    }

    setDefaultDescripcion(userDescripcion: string): void {
        this.form.controls.userDescripcion.setValue(userDescripcion);
    }

    get product_name(): AbstractControl {
        return this.form.controls.userName;
    }

    get product_precio(): AbstractControl {
        return this.form.controls.userPrecio;
    }

    get product_descripcion(): AbstractControl {
        return this.form.controls.userDescripcion;
    }


    updateInvitation(): void {
        let pharmacyName = this.nombreFarmacia;
        let userName = this.product_name.value;
        let userPrecio = this.product_precio.value;
        let userDescripcion = this.product_descripcion.value;
        let id = this.product.id;

        let productRequest = new ProductRequest(userName, userPrecio, userDescripcion, pharmacyName);

        
        this.productService.updateProduct(id, productRequest).subscribe((product) => {
            if (product){
                this.commonService.updateToastData("Success updating product", 'success', 'Product updated.');
                //ir a inicio
                this.router.navigate(['employee']);
               
            }
        });
    }
}