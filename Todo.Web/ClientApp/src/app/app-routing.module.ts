import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  {
    path: '', loadChildren: () => import('./home/home.module').then(m => m.HomeModule)
  },
  {
    path: '', loadChildren: () => import('./signin/signin.module').then(m => m.SigninModule)
  },
  {
    path: '', loadChildren: () => import('./todo/todo.module').then(m => m.TodoModule)
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      routes,
      { preloadingStrategy: PreloadAllModules, relativeLinkResolution: 'legacy' }
    )],
  exports: [RouterModule]
})
export class AppRoutingModule { }
