import { INews } from "./INews.model";

export interface IUser 
{
    id: number;
    userName: string;
    password: string;
    news?: INews;
}

export interface ILocalUser 
{
    id: number;
    userName: string;
}

export interface ILoginUser 
{
    userName: string;
    password: string;
}

export interface IUserChangePassword
{
    previousPassword: string;
    newPassword: string;
}