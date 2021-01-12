import { Tender } from './tender.model';

export  class registerUsers {
  id? :number;
  tenderId ?:Number;
  userId ?:Number;

  user ?:register;
  tender?:Tender;
}
export  class register {
   id? :number;
   name? :string;
   email? :string;
   userType? :string;
   telephone? :string;
   license? :string;
   aadhar? :string;
   panId? :string;
   companyName? :string;
}
