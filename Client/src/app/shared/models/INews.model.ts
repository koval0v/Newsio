import { ISection } from "./ISection.model";
import { ITag } from "./ITag.model";
import { IUser } from "./IUser.model";

export interface INews 
{
    id: number;
    title: string;
    description: string;
    createdDate: Date;
    updatedDate: Date;
    authorId: number;
    author: IUser;
    sectionId: number;
    section: ISection;
    tags: ITag[];
}

export interface ISaveNews 
{
    title: string;
    description: string;
    createdDate: string;
    updatedDate: string;
    authorId: number;
    sectionId: number;
}

export interface IUpdateNews 
{
    id: number;
    title: string;
    description: string;
    createdDate: string;
    updatedDate: string;
    authorId: number;
    sectionId: number;
}