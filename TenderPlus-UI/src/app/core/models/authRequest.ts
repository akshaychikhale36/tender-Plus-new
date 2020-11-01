export class AuthRequest {
  constructor(
      public hkey1: string,
      public hkey2: string
      ) {
  }
}

export class AuthResponse
{
  public id: string;
  public hkey1: string;
  public token: string;

}
