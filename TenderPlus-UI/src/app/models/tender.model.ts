import { bidding } from './bidding.model'

export class Tender {
  Id?: Number
  Title?: string
  Description?: string
  Type?: string
  StartDate?: string
  CloseDate?: string
  Reporter?: string
  Assignee?: string
  Location?: string
  State?: string
  District?: string
  Pin?: string
  Bidding?: bidding
}

