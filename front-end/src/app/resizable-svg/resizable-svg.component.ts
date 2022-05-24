import { AfterViewInit, Component, ElementRef, HostListener, Input, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../data.service';
const enum Status {
  OFF = 0,
  RESIZE = 1,
  MOVE = 2
}
@Component({
  selector: 'app-resizable-svg',
  templateUrl: './resizable-svg.component.html',
  styleUrls: ['./resizable-svg.component.css']
})
export class ResizableSvgComponent implements OnInit, AfterViewInit {

  public width: number = 500;
  public height: number = 450;
  public left: number = 100;
  public top: number = 100;

  @ViewChild("box") public box!: ElementRef;
  private boxPosition!: { left: number; top: number; };
  private containerPos!: { left: number, top: number, right: number, bottom: number };
  public mouse!: {x: number, y: number}
  public status: Status = Status.OFF;
  private mouseClick!: { x: number; y: number; left: number; top: number; }

  constructor(
    private service: DataService
  ) { }

  Id!:string
  ngOnInit(): void {
    this.service.getSvg().subscribe((res:any)=>{
      console.log(res);
      this.Id = res[0].id;
      this.width = res[0].xCord;
      this.height = res[0].yCord
    })
  }
  ngAfterViewInit(){
    this.loadBox();
    this.loadContainer();
  }


  private loadBox(){
    const {left, top} = this.box.nativeElement.getBoundingClientRect();
    this.boxPosition = {left, top};
  }
  private loadContainer(){
    const left = this.boxPosition.left - this.left;
    const top = this.boxPosition.top - this.top;
    const right = left + 1200;
    const bottom = top + 1050;
    this.containerPos = { left, top, right, bottom };
  }

  setStatus(event: MouseEvent, status: number){
    if(status === 1) event.stopPropagation();
    else if(status === 2) this.mouseClick = { x: event.clientX, y: event.clientY, left: this.left, top: this.top };
    else this.loadBox();
    this.status = status;

    // Call update API
    let body = {
      xCord: Math.floor(this.width),
      yCord: Math.floor(this.height)
    }
    console.log(body);
    this.service.updateSvg(this.Id, body).subscribe((res:any)=>{
      console.log(res);
    })
  }

  @HostListener('window:mousemove', ['$event']) onMouseMove(event: MouseEvent){
    this.mouse = { x: event.clientX, y: event.clientY };
    if(this.status === Status.RESIZE) this.resize();
  }

  private resize(){
    if(this.resizeCondMeet()){
      this.width = Number(this.mouse.x > this.boxPosition.left) ? this.mouse.x - this.boxPosition.left : 0;
      this.height = Number(this.mouse.y > this.boxPosition.top) ? this.mouse.y - this.boxPosition.top : 0;
    }
  }

  private resizeCondMeet(){
    return (this.mouse.x < this.containerPos.right && this.mouse.y < this.containerPos.bottom);
  }
  

}
