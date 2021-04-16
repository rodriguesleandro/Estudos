import { Evento } from "./Evento";
import { RedeSocial } from "./RedeSocial";

export interface Palestrante {
        Id: number ;
        Nome: string ;

        MiniCurriculuo: string ;

        ImagemURL: string ;

        Telefone: string ;

        Email: string ;

        RedeSociais: RedeSocial[];

        PalestrantesEventos: Evento[];
}
