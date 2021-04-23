import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';

// import { Evento } from '../models/Evento';
// import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
  // ,providers: [EventoService] //uma forma de injetar dependêncencia
})
export class EventosComponent implements OnInit {

  modalRef!: BsModalRef;
  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) { }

  public get filtroLista(): string{
    return this.filtroListado;
  }
  public set filtroLista(value: string){
    this.filtroListado = value;
    this.eventosFiltrados = this.filtroListado ? this.filtrarEventos(this.filtroListado) : this.eventos;
  }

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  widthImg = 150;
  marginImg = 2;
  isImagemExibida = true;


  private filtroListado = '';

  ngOnInit(): void {


    this.getEventos();
    this.spinner.show();



    // setTimeout(() => {
    //   /** spinner ends after 5 seconds */

    // }, 3000);

  }

  public filtrarEventos(filtrarPor: string): Evento[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (ev => ev.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      || ev.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1

    ));
  }


  exibirImagem(): void{
    this.isImagemExibida = !this.isImagemExibida;
  }

  public getEventos(): void{
    console.log('Puta que pariu');
    this.eventoService.getEventos().subscribe(
      // tslint:disable-next-line: variable-name
      {
      next: (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
                              this.spinner.hide();
                            this.toastr.error(error.message, "Fudeu!")},
      complete: () => this.spinner.hide()
    }
    );
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.toastr.success('Hello world!', 'Toastr fun!');
    this.modalRef.hide();
  }

  decline(): void {
    this.modalRef.hide();
  }

}
