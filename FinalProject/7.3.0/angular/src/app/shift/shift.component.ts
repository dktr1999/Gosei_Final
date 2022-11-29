import { Component, Inject, Injector, InjectorType, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ShiftOfferListDto, ShiftOfferServiceProxy } from '@shared/service-proxies/service-proxies';
import { result } from 'lodash-es';

@Component({
  selector: 'app-shift',
  templateUrl: './shift.component.html',
  styleUrls: ['./shift.component.css']
})
export class ShiftComponent extends AppComponentBase implements OnInit {
  shifts: ShiftOfferListDto[]=[];
  constructor(injector: Injector, private shiftService: ShiftOfferServiceProxy) 
  {
    super(injector);
  }

  days: any[] = [1, 2, 3, 4, 5, 6, 7]
  weekday: any[] = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
  dateNow: Date = new Date;
  dateEnd = "";
  dateStart = "";

  n = this.dateNow.getDay();
  checkWeek = 0;
  status = "This Week";
  ngOnInit(): void {
    for (let i = 0; i < this.days.length; i++) {

      if (this.dateNow.getDay() == 0) {
        this.n = 7;
      } else {
        this.n = this.dateNow.getDay();
      }
      this.dateNow.setDate(this.dateNow.getDate() - this.n + i + 1);
      if (i == 0) {
        this.dateStart = this.dateNow.getDate() + "/" + this.dateNow.getMonth() + "/" + this.dateNow.getFullYear();
      }
      if (i == 6) {
        this.dateEnd = this.dateNow.getDate() + "/" + this.dateNow.getMonth() + "/" + this.dateNow.getFullYear();
      }

      this.days[i] = this.weekday[this.dateNow.getDay()] + " " + this.dateNow.getDate();
    }

    this.getShifts();
  }

  getShifts(){
    this.shiftService.getAllShift().subscribe(result => {
      this.shifts = result.items;
    })
  }

  LeftButton() {
    this.dateNow.setDate(this.dateNow.getDate() - 7);
    this.checkWeek = this.checkWeek - 1;
    this.ngOnInit();
    console.log(this.dateStart + "  " + this.dateEnd);
    if (this.checkWeek == -1) {
      this.status = "Last Week";
    } else if (this.checkWeek == 0) {
      this.status = "This Week";
    } else if (this.checkWeek < -1) {
      this.status = this.dateStart + " - " + this.dateEnd;
    } else if (this.checkWeek == 1) {
      this.status = "Next Week";
    }
  }

  RightButton() {
    this.dateNow.setDate(this.dateNow.getDate() + 7);
    this.checkWeek = this.checkWeek + 1;
    this.ngOnInit();
    console.log(this.dateStart + "  " + this.dateEnd);
    if (this.checkWeek == 1) {
      this.status = "Next Week";
    } else if (this.checkWeek == 0) {
      this.status = "This Week";
    } else if (this.checkWeek > 1) {
      this.status = this.dateStart + " - " + this.dateEnd;
    } else if (this.checkWeek == -1) {
      this.status = "Last Week";
    }
  }

  statusShift = 'd-none';
  currentDay = '';
  MouseEnter(day: string) {
    this.statusShift = '';
    this.currentDay = day;
  }

  MouseLeave() {
    this.statusShift = 'd-none';
    this.currentDay = '';
  }

  SetStatusShift() {
    this.statusShift = 'd-none';
  }
  checkAccept = 1;
  isAccept = false;
  IsAccept() {
    this.checkAccept = 1;
    this.isAccept = !this.isAccept;

  }
  OffAccept(){
    if(this.checkAccept % 2 == 1){
      this.checkAccept = 2;
    }else{
      this.isAccept = false;
    }
  }
  checkReject = 1;
  isReject = false;
  IsReject() {
    this.checkReject = 1;
    this.isReject = !this.isReject;
  }
  
  OffReject(){
    if(this.checkReject % 2 == 1){
      this.checkReject = 2;
    }else{
      this.isReject = false;
    }
  }
}
