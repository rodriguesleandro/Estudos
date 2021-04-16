import { Lote } from "./Lote";
import { Palestrante } from "./Palestrante";
import { RedeSocial } from "./RedeSocial";

export interface Evento {
  Id: number;

  QtdPessoas: number;

  Local: string

  DataEvento?: Date;

  Tema: string;

  ImagemURL: string;

  Telefone: string;

  Email: string;

  Lotes: Lote[];

  RedesSociais: RedeSocial[];

  PalestrantesEventos: Palestrante[];
}
