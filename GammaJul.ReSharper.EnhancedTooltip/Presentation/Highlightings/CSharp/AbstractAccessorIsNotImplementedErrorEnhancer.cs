using GammaJul.ReSharper.EnhancedTooltip.DocumentMarkup;
using JetBrains.Annotations;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Daemon.CSharp.Errors;
using JetBrains.ReSharper.Psi.CodeAnnotations;
using JetBrains.ReSharper.Psi.Resolve;

namespace GammaJul.ReSharper.EnhancedTooltip.Presentation.Highlightings.CSharp {

	[SolutionComponent]
	internal sealed class AbstractAccessorIsNotImplementedErrorEnhancer : CSharpHighlightingEnhancer<AbstractAccessorIsNotImplementedError> {

		protected override void AppendTooltip(AbstractAccessorIsNotImplementedError highlighting, CSharpColorizer colorizer) {
			colorizer.AppendPlainText("Abstract inherited member '");
			colorizer.AppendDeclaredElement(highlighting.InheritorDeclaration.DeclaredElement, EmptySubstitution.INSTANCE, PresenterOptions.ForInterfaceMember);
			colorizer.AppendPlainText("' is missing ");
			colorizer.AppendAccessorKind(highlighting.MissedAccessor.Kind);
			colorizer.AppendPlainText(" accessor implementation");
		}

		public AbstractAccessorIsNotImplementedErrorEnhancer(
			[NotNull] TextStyleHighlighterManager textStyleHighlighterManager,
			[NotNull] CodeAnnotationsCache codeAnnotationsCache,
			[NotNull] HighlighterIdProviderFactory highlighterIdProviderFactory)
			: base(textStyleHighlighterManager, codeAnnotationsCache, highlighterIdProviderFactory) {
		}

	}

}