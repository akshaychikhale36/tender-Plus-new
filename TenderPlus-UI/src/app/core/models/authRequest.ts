export class AuthRequest {
 username:string;
 password:string;
}

export class AuthResponse
{
  public id: string;
  public username: string;
  public token: string;
  public role:string;

}
