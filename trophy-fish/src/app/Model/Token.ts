export interface Token {
    access_token: string;
    expires_in: number;
    id_token:string;
    refresh_token:string;
    resource:string;
    token_type:string;
}