import { Service } from '@app/core/service-helper/service';
import { Injectable } from '@angular/core';
import { HttpBaseService } from '@app/core/service-helper/HttpBaseService';


@Injectable()
export class LivroService {
    private url = Service.API_ENDPOINT + 'Livro';

    constructor(private service: HttpBaseService) { }

    get() {
        return this.service.get(this.url, null);
    }

    getById(id: any) {
        return this.service.get(this.url, id);
    }

    add(obj: any) {
        return this.service.post(this.url, obj);
    }

    update(obj: any) {
        return this.service.put(this.url, obj);
    }

    delete(id: any) {
        return this.service.delete(this.url, id);
    }
}
