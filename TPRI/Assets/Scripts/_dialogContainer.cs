using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _dialogContainer : MonoBehaviour
{
    protected Dictionary<string, string> BaseDialogs = new Dictionary<string, string>();
    protected Dictionary<string, string> WhereDialogs = new Dictionary<string, string>();
    protected Dictionary<string, string> ProblemsDialogs = new Dictionary<string, string>();
    protected List<string> VisitDialogs = new List<string>();
    void Awake()
    {
       BaseDiaolgsInitial();
       WhereDiaolgsInitial();
       ProblemsDiaolgsInitial();
       VisitDiaolgsInitial();
    }
    private void BaseDiaolgsInitial() {
        BaseDialogs.Add("Простуда", "Здравствуйте!(сопливит). Меня зовут ");
        BaseDialogs.Add("Чесотка", "Добрейшего!. Меня кличут ");
        BaseDialogs.Add("Мигрень", "Здарова! Меня зовут ");
        BaseDialogs.Add("Гастрит", "Здаравейшага!(держится за живот). Я - ");
        BaseDialogs.Add("Гепатит", "Здравствуйте!. Меня зовут ");
        BaseDialogs.Add("Грипп", "Аве! Меня зовут ");
        BaseDialogs.Add("Туберкулез", "Ола!(часто и долго кашляет). Мяне звать ");
        BaseDialogs.Add("Корь", "Здравствуйте! Меня зовут ");
        BaseDialogs.Add("Бронхит", "Здравствуйте!(выглядит ослабленным). Меня зовут ");
        BaseDialogs.Add("Язва", "Здраве! Меня зовут ");
        BaseDialogs.Add("Менингит", "...(выглядит ужасно, держится за голову) Я -");
        BaseDialogs.Add("Коронавирус", "...(еле поднял руку для приветствия) Я - ");
        BaseDialogs.Add("Пневмония", "Здровия! Меня зовут ");
        BaseDialogs.Add("Рак", "Здравие! Звать мяне ");
        BaseDialogs.Add("Цинга", "Здравст...(изо рта кровь). Я - ");
        BaseDialogs.Add("HEALTHY", "Добрейшего времени суток. Я - ");
    }
    private void WhereDiaolgsInitial() {
        WhereDialogs.Add("Простуда", "Я путник, где только не бывал");
        WhereDialogs.Add("Чесотка", "Заплутал в лесу(характерно чешется)");
        WhereDialogs.Add("Мигрень", "Из соседней деревушки(говорит тихо)");
        WhereDialogs.Add("Гастрит", "Из города за 3-девять земель");
        WhereDialogs.Add("Гепатит", "Не важно откуда");
        WhereDialogs.Add("Грипп", "С лесопилки(явно утомлен)");
        WhereDialogs.Add("Туберкулез", "Из соседнего царства, бегу оттуда");
        WhereDialogs.Add("Корь", "Из лесу(характерная сыпь)");
        WhereDialogs.Add("Бронхит", "С севера путь держу");
        WhereDialogs.Add("Язва", "С празднования повышения по службе");
        WhereDialogs.Add("Менингит", "Иду долго, ищу приют на время");
        WhereDialogs.Add("Коронавирус", "Из... соседнего... (отрубился)");
        WhereDialogs.Add("Пневмония", "Я не знаю откуда иду");
        WhereDialogs.Add("Рак", "ИСЦЕЛИТЕ МЕНЯ, ХВАТИТ ВОПРОСОВ");
        WhereDialogs.Add("Цинга", "С моря путь держу");
        WhereDialogs.Add("HEALTH", "В гости пришел");
       
    }
    private void ProblemsDiaolgsInitial() {
        ProblemsDialogs.Add("Простуда", "Сами слухайте, насморк");
        ProblemsDialogs.Add("Чесотка", "Вам виднее. Мне бы обмыться");
        ProblemsDialogs.Add("Мигрень", "Шумит в голове. Говорите тише!");
        ProblemsDialogs.Add("Гастрит", "Изжога мучает. Пригубил бы воды");
        ProblemsDialogs.Add("Гепатит", "В пот кидает");
        ProblemsDialogs.Add("Грипп", "Вы должны мне сказать");
        ProblemsDialogs.Add("Туберкулез", "Временами слабость");
        ProblemsDialogs.Add("Корь", "Не могу сказать точно");
        ProblemsDialogs.Add("Бронхит", "Все думают, что облаиваю их");
        ProblemsDialogs.Add("Язва", "Боли, как будто трапезничать хочу");
        ProblemsDialogs.Add("Менингит", "Тошнит часто, скоро на изнанку вывернусь");
        ProblemsDialogs.Add("Коронавирус", "(пришел в себя) Плохо мне, лекарь");
        ProblemsDialogs.Add("Пневмония", "Знобит мммееееннняя");
        ProblemsDialogs.Add("Рак", "Я ПИЩУ ОТВЕДАТЬ НЕ МОГУ");
        ProblemsDialogs.Add("Цинга", "(выплюнул зуб)");
        ProblemsDialogs.Add("HEALTHY", "Да я даже не ведаю");
    }
    private void VisitDiaolgsInitial() {
        VisitDialogs.Add("Переночевать ищу место");
        VisitDialogs.Add("Ищу родню");
        VisitDialogs.Add("В гости к друзьям");
        VisitDialogs.Add("Просто проходил мимо");
        VisitDialogs.Add("Вам не понять");
        VisitDialogs.Add("Жить тут буду");
        VisitDialogs.Add("А это так важно?");
        VisitDialogs.Add("Не могу сказать точно");
        VisitDialogs.Add("Поспать на нормальном месте");
        VisitDialogs.Add("Я не знать, что я тут, ик");
        VisitDialogs.Add("Переждать непогоду");
        VisitDialogs.Add("Не ведаю ... зачем ... пришел");
        VisitDialogs.Add("Не знаю, куда пришел");
        VisitDialogs.Add("ДАЙ УЖЕ ПИЛЮЛЮ");
        VisitDialogs.Add("Ожидать следующего плаванья");
    }
}
