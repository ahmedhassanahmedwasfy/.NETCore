import { Component, OnDestroy, Input, OnInit } from '@angular/core';
import { NbLayoutDirectionService, NbLayoutDirection } from '@nebular/theme';
import { takeWhile } from 'rxjs/operators/takeWhile';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'ngx-layout-direction-switcher',
  template: `
    <ngx-switcher
      [firstValue]="directions.RTL"
      [secondValue]="directions.LTR"
      [firstValueLabel]="loc_RTL"
      [secondValueLabel]="loc_LTR"
      [value]="currentDirection"
      (valueChange)="toggleDirection($event)"
      [vertical]="vertical"
    >
    </ngx-switcher>
  `,
})
export class LayoutDirectionSwitcherComponent implements OnDestroy, OnInit {
  async ngOnInit() {
    this.localize();
  }
  async localize() {
    this.loc_LTR = await this.translate.get('LTR').toPromise();
    this.loc_RTL = await this.translate.get('RTL').toPromise();

  }
  directions = NbLayoutDirection;
  currentDirection: NbLayoutDirection;
  alive = true;
  loc_RTL; loc_LTR;
  @Input() vertical: boolean = false;

  constructor(private directionService: NbLayoutDirectionService, private translate: TranslateService) {
    this.currentDirection = this.directionService.getDirection();
    this.translate.onLangChange.subscribe(res => { this.localize() });
    this.directionService.onDirectionChange()
      .pipe(takeWhile(() => this.alive))
      .subscribe(newDirection => this.currentDirection = newDirection);
  }

  toggleDirection(newDirection) {
    this.directionService.setDirection(newDirection);
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
