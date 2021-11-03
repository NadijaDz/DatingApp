import { Photo } from "./photo";

 export interface Member {
        Id: number;
        UserName: string;
        Gender: string;
        Age: string;
        KnownAs: string;
        Created: Date;
        LastActive: Date;
        Introduction: string;
        LookingFor: string;
        Interests: string;
        City: string;
        Country: string;
        PhotoUrl: string;
        Photos: Photo[];
    }

