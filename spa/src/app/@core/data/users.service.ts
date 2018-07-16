
import { of as observableOf,  Observable } from 'rxjs';
import { Injectable } from '@angular/core';


let counter = 0;

@Injectable()
export class UserService {

  private users = {
    nick: { name: 'Rasmus', picture: 'assets/images/xD.png' },
    eva: { name: 'Jens Petur', picture: 'assets/images/faggotdog.jpg' },
    jack: { name: 'Morfar', picture: 'assets/images/thinking-dog.jpg' },
    lee: { name: 'Andreas', picture: 'assets/images/wtfdog.png' },
    alan: { name: 'Thomas', picture: 'assets/images/ITried.png' },
    kate: { name: 'Frederik ', picture: 'assets/images/laughingdog.JPG' },
  };

  private userArray: any[];

  constructor() {
    // this.userArray = Object.values(this.users);
  }

  getUsers(): Observable<any> {
    return observableOf(this.users);
  }

  getUserArray(): Observable<any[]> {
    return observableOf(this.userArray);
  }

  getUser(): Observable<any> {
    counter = (counter + 1) % this.userArray.length;
    return observableOf(this.userArray[counter]);
  }
}
