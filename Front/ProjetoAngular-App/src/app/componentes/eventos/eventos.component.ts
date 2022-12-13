import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/evento.service';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
  // providers: [EventoService] //forma de injeção de dependencia
})
export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
  message?: string;

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  public larguraImg = 150;
  public margemImg = 2;
  public mostrarImg = true;
  public filtroListado = '';

  public get filtroLista()
  {
    return this.filtroListado;
  }

  public set filtroLista(value: string)
  {
    this.filtroListado = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[]
  {
      filtrarPor = filtrarPor.toLocaleLowerCase();

      return this.eventos.filter(
        (evento: Evento) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      )
  }

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    )
    {


    }

  public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public exibirImagem(){
    this.mostrarImg = !this.mostrarImg;
  }

  public getEventos(): void
  {
    this.eventoService.getEvento().subscribe({
      next: (eventosResp: Evento[]) =>
      {
        this.eventos = eventosResp;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        this.spinner.hide(),
        this.toastr.error('Erro ao carregar os eventos','Erro');
      },

      complete: () => {this.spinner.hide()}

    });
  }

  config = {
    keyboard: true
  };

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Evento deletado!','Sucesso');
  }

  decline(): void {
    this.message = 'Deletado!';
    this.modalRef?.hide();
  }

}
