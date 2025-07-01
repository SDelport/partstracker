import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', loadComponent: () => import('./part-list-component/part-list-component').then(m => m.PartListComponent) },
    {
        path: 'create',
        loadComponent: () =>
            import('./part-form/part-form').then(m => m.PartFormComponent),
    },
    {
        path: ':id/edit',
        loadComponent: () =>
            import('./part-form/part-form').then(m => m.PartFormComponent),
    },
    {
        path: ':id',
        loadComponent: () =>
            import('./part-detail/part-detail').then(m => m.PartDetailComponent),
    },
];
