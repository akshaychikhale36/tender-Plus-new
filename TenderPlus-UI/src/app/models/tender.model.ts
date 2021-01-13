import { bidding } from './bidding.model'
import { registerUsers } from './register.model'

export class Tender {
  id?: Number
  title?: string
  description?: string
  type?: string
  startDate?: string
  closeDate?: string
  reporter?: string
  assignee?: string
  location?: string
  state?: string
  district?: string
  pin?: string
  bidding?: bidding
  tenderUsers?:registerUsers
}

