import { RouterModule, Routes } from '@angular/router';
import { MyBodyComponent } from './my-body/my-body.component'

const routesConfig: Routes = [
    { path: ':mode', component: MyBodyComponent },
    { path: '**', redirectTo: 'all', pathMatch: 'full' }
];

export const routerModule = RouterModule.forRoot(routesConfig);
