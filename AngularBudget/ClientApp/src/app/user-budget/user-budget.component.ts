import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { forkJoin } from 'rxjs';
import { FormBuilder, FormGroup, FormArray, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-budget',
  templateUrl: './user-budget.component.html',
  styleUrls: ['./user-budget.component.css']
})
export class UserBudgetComponent implements OnInit {
  public userBudget: UserBudget | undefined = undefined;
  public frequencies: Frequency[] | undefined = undefined;
  public loading: boolean = true;
  public form: FormGroup;
  private readonly http: HttpClient;
  private readonly baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder) {
    this.http = http;
    this.baseUrl = baseUrl;

    this.form = this.formBuilder.group({
      frequencies: [''],
      frequencyAmount: ['']
    });

    forkJoin(
      {
        userBudget: this.http.get<UserBudget>(`${this.baseUrl}api/userbudgets`),
        frequencies: this.http.get<Frequency[]>(`${this.baseUrl}api/frequencies`)
      }
    ).subscribe(( data ) => {
      this.userBudget = data.userBudget;
      console.log(this.userBudget);
      this.frequencies = data.frequencies;
      this.form.controls.frequencies.patchValue(this.frequencies[2].frequencyId);
      this.form.controls.frequencyAmount.patchValue(1);
      this.loading = false;
    });
    //http.get<UserBudget>(`${baseUrl}api/userbudgets`).subscribe(result => {
    //  this.userBudget = result;
    //  if (result)
    //    console.log("There is a result!");
    //  else
    //    console.log("No result");
    //  this.loading = false;
    //}, error => console.error(error));
  }

  ngOnInit(): void {
  }

  get f() {
    return this.form.controls;
  }

  onSubmit() {
    console.log(this.form.value);
    let newBudget: UserBudget = {
      frequencyId: this.form.value.frequencies,
      frequencyAmount: this.form.value.frequencyAmount
    };
    console.log(newBudget);
    this.http.post<UserBudget>(`${this.baseUrl}api/userbudgets`, newBudget).subscribe((data) => { console.log(data); this.userBudget = data; });

  }

  getFrequencyById(id: number): string {
    return this.frequencies?.find(element => element.frequencyId == id)?.frequencyName ?? '';
  }

}


interface UserBudget {
  userBudgetId?: string;
  frequencyId: number;
  frequencyAmount: number;
}

interface Frequency {
  frequencyId: number;
  frequencyName: string;
}

